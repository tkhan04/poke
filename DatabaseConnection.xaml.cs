using MongoDB.Driver;
using MongoDB.Bson;
using System;
//const string connectionUri = "mongodb+srv://tkhanpsn:<password>@pokedex.mayccu6.mongodb.net/?retryWrites=true&w=majority&appName=PokeDex"; 
//^^ THERE COULD BE AN ERROR WITH THE CONNECTION STRING, CHECK AGAIN IF IT DOESNT WORK
const string connectionUri = "mongodb+srv://tkhanpsn:Pokegocult@pokedex.mayccu6.mongodb.net/?retryWrites=true&w=majority&appName=PokeDex";

var settings = MongoClientSettings.FromConnectionString(connectionUri);
settings.ServerApi = new ServerApi(ServerApiVersion.V1);

var client = new MongoClient(settings);

try {
    var result = client.GetDatabase("admin").RunCommand<BsonDocument>(new BsonDocument("ping", 1));
    Console.WriteLine("Pinged your deployment. You successfully connected to MongoDB!");

    var database = client.GetDatabase("PokeDex");
    var collection = database.GetCollection<BsonDocument>("Pokemon");

  string pokemonName = "Pikachu"; // GET FROM USER INPUT OR REFER TO THE OTHER CLASS THAT TAKES IT AS INPUT

    var filter = Builders<BsonDocument>.Filter.Eq("Name", pokemonName);

    var pokemon = collection.Find(filter).FirstOrDefault();

    if (pokemon != null) {
        Console.WriteLine($"Found Pokémon: {pokemonName}");
        Console.WriteLine(pokemon.ToJson());
    } else {
        Console.WriteLine("No Pokémon found with the specified name.");
    }
} catch (Exception ex) {
    Console.WriteLine($"An error occurred: {ex.Message}");
}
