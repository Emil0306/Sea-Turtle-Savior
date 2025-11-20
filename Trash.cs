// Trash class for creating Trash, which can be used to make lists of them in different rooms.
namespace SeaTurtleSavior;

public class Trash
{
	private string name;
	private string material;
	private bool forbiddenMaterial;

	public Trash(string name, string material, bool forbiddenMaterial)
	{
		this.name = name;
		this.material = material;
		this.forbiddenMaterial = forbiddenMaterial;
	}
	
	public string GetName()
	{
		return name;
	}
	
	public string GetMaterial()
	{
		return material;
	}

	public bool GetForbiddenMaterial()
	{
		return forbiddenMaterial;
	}
}