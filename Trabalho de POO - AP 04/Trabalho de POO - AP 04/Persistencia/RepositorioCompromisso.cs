using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using CompromissosApp.Modelos;

namespace CompromissosApp.Persistencia
{
    public class RepositorioCompromissos
    {
        private readonly string _filePath = "compromissos.json"; 

        public List<Usuario> CarregarDados()
        {
            if (File.Exists(_filePath))
            {
                string jsonString = File.ReadAllText(_filePath);
                
                return JsonSerializer.Deserialize<List<Usuario>>(jsonString);
            }
            return new List<Usuario>(); 
        }

        public void SalvarDados(List<Usuario> usuarios)
        {
            var options = new JsonSerializerOptions { WriteIndented = true }; 
            string jsonString = JsonSerializer.Serialize(usuarios, options);
            File.WriteAllText(_filePath, jsonString);
        }
    }
}