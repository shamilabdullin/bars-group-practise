using Microsoft.Extensions.Localization.Internal;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Teams.Mongo.Model
{
    public class Team
{	
	[BsonRepresentation(BsonType.ObjectId)]
	public int Id { get; set; }

	[BsonElement("name")]
	[Display(Name = «Имя_команды")]
	public string Name { get; set; }
	
	[BsonElement("sport")]
	[Display(Name = « Вид спорта)]
	public string Wins { get; set; }


}

}
