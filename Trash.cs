// Trash class for creating Tash, which can be used to make lists of them in different rooms.
class Trash
{
	public string Name {get;}
	public string Material {get;}
	public bool ForbiddenMaterial {get;}

	public Trash(string Name, string Material, bool forbiddenMaterial)
	{
		this.Name = Name;
		this.Material = Material;
		this.ForbiddenMaterial = forbiddenMaterial;
	}
}
