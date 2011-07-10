using MongoDB.Bson;

namespace AppHarborMongoDBDemo.Models
{
	public class Thingy
	{
		public ObjectId Id { get; set; }
		public string Name { get; set; }
	}
}
