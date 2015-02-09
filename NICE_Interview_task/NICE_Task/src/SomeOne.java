
public class SomeOne implements ISomeOne {
	public int age;
	public String firstName;
	public String name;
	public String lastName;
	public String breed;
	public double weight;
	public double height;

	public SomeOne(int age,String firstName,String name,String lastName,String breed,double weight,double height) {
		this.age=age;
		this.firstName=firstName;
		this.name=name;
		this.lastName=lastName;
		this.breed=breed;
		this.weight=weight;
		this.height=height;
	}
	
	public SomeOne() {
		
	}
	
	@Override
	public int getAge() {
		return age;
	}

	@Override
	public double getWeight() {
		return weight;
	}
}
