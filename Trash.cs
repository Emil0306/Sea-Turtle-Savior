// Trash class for creating Tash, which can be used to make lists of them in different rooms.
class Trash
{
	public string Name {get;}
	public string Material {get;}

	public Trash(string Name, string Material)
	{
		this.Name = Name;
		this.Material = Material;
	}
}
