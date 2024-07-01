using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebApi.Models
{
	public class Cargo
	{
		public int Id { get; set; }
		public int Size { get; set; }
		public int Weight { get; set; }
		public string Date { get; set; } = 	"";		
		public string Description { get; set; } = "";
		public int? WaypointId { get; set; }     
		public Waypoint? Waypoint { get; set; }
		public int? RouteId { get; set; }
		public MapRoute? Route { get; set; } 
	}
}
