using CosmosDBSQLAPI.Models;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmosDBSQLAPI.Helpers
{
    public class CosmosDBHelper
    {
        private DocumentClient documentClient;
        private string database;
        private string collection;
        public CosmosDBHelper(string uri, string key, string database, string collection)
        {
            this.database = database;
            this.collection = collection;
            documentClient = new DocumentClient(new Uri(uri), key);
            documentClient.CreateDatabaseIfNotExistsAsync(new Database { Id = database }).GetAwaiter().GetResult();
            documentClient.CreateDocumentCollectionIfNotExistsAsync(
                UriFactory.CreateDatabaseUri(database), new DocumentCollection
                {
                    Id = collection,
                    PartitionKey = new PartitionKeyDefinition
                    {
                        Paths = new Collection<string>(new List<string>() { "/category" })
                    }
                }).GetAwaiter().GetResult();
        }

        public async Task<object> InsertDocumentAsync(Cars car)
        {
            ResourceResponse<Document> response = null;
            //try
            //{
            //    var document = await documentClient.ReadDocumentAsync(
            //    UriFactory.CreateDocumentUri(database, collection, car.Id));
            //    Console.WriteLine("Document Already Exist");
            //}
            //catch (DocumentClientException ex)
            //{
            //    if (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            //    {
            response = await documentClient.CreateDocumentAsync(
                UriFactory.CreateDocumentCollectionUri(database, collection), car);
            //        Console.WriteLine("Document Added");
            //    }                
            //}
            return response;
        }

        public IQueryable<Cars> GetCars()
        {
            IQueryable<Cars> cars = documentClient.CreateDocumentQuery<Cars>(
                UriFactory.CreateDocumentCollectionUri(database, collection),
                "select * from cars",
                new FeedOptions { EnableCrossPartitionQuery=true });
            return cars;
        }

    }
}
