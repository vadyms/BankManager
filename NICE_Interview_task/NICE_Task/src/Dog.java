public class Dog implements ISomeOne {
	public int age;
	public String name;
	public String breed;
	public double weight;
	
	
	public Dog(int age,String name,String breed,double weight) {
		this.age=age;
		this.name=name;
		this.breed=breed;
		this.weight=weight;
	}
	
	@Override
	public int getAge() {
		return age;
	}

	public String getName() {
		return name;
	}

	public String getBreed() {
		return breed;
	}

	@Override
	public double getWeight() {
		return weight;
	}
}