import java.util.ArrayList;
import java.util.Collection;

public class Program {

    //================================================================================
    // interface
    //================================================================================
	public interface Predicate<T> { boolean apply(T type); }
	
    //================================================================================
    // Collection filter definition
    //================================================================================
	public static <T> Collection<T> filter(Collection<T> col, Predicate<T> predicate) {
		  Collection<T> result = new ArrayList<T>();
		  for (T element: col) {
		    if (predicate.apply(element)) {
		      result.add(element);
		    }
		  }
		  return result;
	}
	
	public static void main(String[] args) {
	    //================================================================================
	    // Persons objects
	    //================================================================================
		
		ArrayList<Person> people=new ArrayList<Person>();
		
		people.add(new Person(12,"FN1","LN1",12,120));
		people.add(new Person(25,"FN2","LN2",31,180));
		people.add(new Person(31,"FN3","LN3",56,170));
		
	    //================================================================================
	    // Task 1
	    //================================================================================
		System.out.println("Part 1: Person’s age > 30");
		class PersonFilterPredicate implements Predicate<Person>
		{
			  public boolean apply(Person person) {
				    return person.getAge() > 30;
				  }
		}
		Predicate<Person> validPersonPredicate = new  PersonFilterPredicate();
			 
		Collection<Person> result = filter(people, validPersonPredicate);
		for(Person p : result) {
			System.out.println(p.age+" "+ p.firstName);
		}
		
	    //================================================================================
	    // Task 2
	    //================================================================================
		System.out.println("Part 2: Person’s age < X (where X may be a number between 0-120)");
		int iExpectedAge=25;
		int iAgeMin=0;
		int iAgeMax=120;
		
		validPersonPredicate = new Predicate<Person>() {
			  public boolean apply(Person person) {
			    return person.getAge() > iAgeMin && person.getAge() < iAgeMax && person.getAge() == iExpectedAge;
			  }
			};
			 
		result = filter(people, validPersonPredicate);
		for(Person p : result) {
			System.out.println(p.age+" "+ p.firstName);
		}
		
	    //================================================================================
	    // Task 3
	    //================================================================================
		System.out.println("Part 3: Person’s first name contains the latter L (where L is a letter from A-Z)");
		String sFirstNameLetter="L";
		
		validPersonPredicate = new Predicate<Person>() {
			  public boolean apply(Person person) {
			    return person.getFirstName().contains(sFirstNameLetter);
			  }
			};
			 
		result = filter(people, validPersonPredicate);
		for(Person p : result) {
			System.out.println(p.age+" "+ p.firstName);
		}
		
	    //================================================================================
	    // Task 4
	    //================================================================================
		System.out.println("Part 4: Condition located in the apply function for predicate");
		
		validPersonPredicate = new Predicate<Person>() {
			  public boolean apply(Person person) {
			    return person.getFirstName().contains(sFirstNameLetter);
			  }
			};
			 
		result = filter(people, validPersonPredicate);
		for(Person p : result) {
			System.out.println(p.age+" "+ p.firstName);
		}
		
	    //================================================================================
	    // Task 5
	    //================================================================================
		System.out.println("Part 5: Dog’s age > 7");
		ArrayList<Dog> dogs=new ArrayList<Dog>();
		
		dogs.add(new Dog(1, "N1","B1",1));
		dogs.add(new Dog(10,"N2","B2",50));
		dogs.add(new Dog(7, "N3","B3",20));
		
		
		Predicate<Dog> validDogPredicate = new Predicate<Dog>() {
			  public boolean apply(Dog dog) {
			    return dog.getAge()>7;
			  }
			};
			 
		Collection<Dog> resultDogs = filter(dogs, validDogPredicate);
		for(Dog d : resultDogs) {
			System.out.println(d.age+" "+ d.name);
		}
		
	    //================================================================================
	    // Task 6
	    //================================================================================
		System.out.println("Part 6: Dog’s weight > X (where X is a number between 0-100) in kg.");
		int iExpectedWeight=1;
		int iWeightMin=0;
		int iWeightMax=100;
		
		validDogPredicate = new Predicate<Dog>() {
			  public boolean apply(Dog dog) {
			    return dog.getWeight()>iWeightMin && dog.getWeight()<iWeightMax && dog.getWeight()==iExpectedWeight;
			  }
			};
			 
		resultDogs = filter(dogs, validDogPredicate);
		for(Dog d : resultDogs) {
			System.out.println(d.age+" "+ d.name);
		}
		
	    //================================================================================
	    // Task 7
	    //================================================================================
		System.out.println("Part 7: Dog’s breed equals to X (where X is a String such as “Boxer”).");
		String sExpectedBreed="Boxer";
		
		validDogPredicate = new Predicate<Dog>() {
			  public boolean apply(Dog dog) {
			    return dog.getBreed()==sExpectedBreed;
			  }
			};
			 
		resultDogs = filter(dogs, validDogPredicate);
		for(Dog d : resultDogs) {
			System.out.println(d.age+" "+ d.name);
		}
		
	    //================================================================================
	    // Task 8
	    //================================================================================
		System.out.println("Part 8: SomeOne");
		ArrayList<SomeOne> someOne=new ArrayList<SomeOne>();
		someOne.add(new SomeOne(1,"1","1","1","1",1,1));
		
		Predicate<SomeOne> validSomeOnePredicate = new Predicate<SomeOne>() {
			  public boolean apply(SomeOne someOne) {
			    return true; // here should be added condition validate object property, function,...
			  }
			};
			 
		Collection<SomeOne> resultSomeOne = filter(someOne, validSomeOnePredicate);
		for(SomeOne s : resultSomeOne) {
			System.out.println(s.age+" "+ s.name); ///....
		}
	}
}
