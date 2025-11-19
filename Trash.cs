// Trash class for creating Trash, which can be used to make lists of them in different rooms.
public class Trash
{
	public string Name {get;}
	public string Material {get;}
	public bool ForbiddenMaterial {get;}

	public Trash(string Name, string Material, bool ForbiddenMaterial)
	{
		this.Name = Name;
		this.Material = Material;
		this.ForbiddenMaterial = ForbiddenMaterial;
	}
}