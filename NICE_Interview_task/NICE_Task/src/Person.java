public class Person implements ISomeOne {
	public int age;
	public String firstName;
	public String lastName;
	public double weight;
	public double height;
	
	public Person(int age, String firstName, String lastName, double weight, double height) {
		this.age=age;
		this.firstName=firstName;
		this.lastName=lastName;
		this.weight=weight;
		this.height=height;
	}

	@Override
	public int getAge() {
		// TODO Auto-generated method stub
		return age;
	}

	public String getFirstName() {
		// TODO Auto-generated method stub
		return firstName;
	}

	public String getLastName() {
		// TODO Auto-generated method stub
		return lastName;
	}

	@Override
	public double getWeight() {
		// TODO Auto-generated method stub
		return weight;
	} 
	public double getHeight() {
		return height;
	}
	
}
