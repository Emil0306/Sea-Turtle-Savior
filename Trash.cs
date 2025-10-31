class Trash {
	private string name;
	private string material;

	public Trash(string name, string material){
		this.name = name;
		this.material = material;
	}

	public string GetMaterial(){
		return material;
	}
	public string GetName(){
		return name;
	}
}