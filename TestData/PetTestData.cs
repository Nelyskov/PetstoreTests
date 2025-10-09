using System.Collections.Generic;
using PetstoreTests.Models;
using PetstoreTests.Helpers;
using System.IO;
using System.Text.Json;

namespace PetstoreTests.TestData
{
    public static class PetTestData
    {
        private static string GetJsonFilePath(string fileName)
        {
            return Path.Combine(Directory.GetCurrentDirectory(), "TestData", fileName);
        }

        public static IEnumerable<Pet> GetPetJsonBody
        {
            get
            {
                var json = File.ReadAllText(GetJsonFilePath("pets.json"));
                return JsonHelper.Deserialize<List<Pet>>(json);
            }
        }

        public static IEnumerable<long> GetPetsId
        {
            get
            {
                var json = File.ReadAllText(GetJsonFilePath("petsID.json"));
                return JsonHelper.Deserialize<List<long>>(json);
            }
        }

        public static IEnumerable<string> GetPetsStatus
        {
            get
            {
                var json = File.ReadAllText(GetJsonFilePath("petsStatus.json"));
                return JsonHelper.Deserialize<List<string>>(json);
            }
        }

        public static IEnumerable<JsonBodyToUpdatePet> PostPetFormToUpdate
        {
            get
            {
                var json = File.ReadAllText(GetJsonFilePath("petsFormsToUpdate.json"));
                return JsonHelper.Deserialize<List<JsonBodyToUpdatePet>>(json);
            }
        }

    }

    public class JsonBodyToUpdatePet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public PetStatus Status { get; set; }
    }
}