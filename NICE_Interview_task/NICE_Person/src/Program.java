import java.util.ArrayList;
import java.util.List;
import java.util.stream.Collectors;


public class Program {

	public static void main(String[] args) {
		List<Person> aPersons = new ArrayList<Person>();
		aPersons.add(new Person(5,"FN1","LN2",120,60));
		aPersons.add(new Person(25,"FN2","LN2",160,70));
		aPersons.add(new Person(31,"FN3","LN3",180,90));
		
		System.out.println("Part 1: > 30");
		List<Person> filterred1=aPersons.stream()
				.filter(p -> p.age>30).collect(Collectors.toList());
		for(Person p : filterred1) {
			System.out.println(p.age);
		}
		
		System.out.println("Part 2: >0 and < 120");
		List<Person> filterred2=aPersons.stream()
				.filter(p -> p.age>0).filter(p->p.age<120).collect(Collectors.toList());
		for(Person p : filterred2) {
			System.out.println(p.age);
		}
		
		System.out.println("Part 3: First name have 'L'");
		List<Person> filterred3=aPersons.stream()
				.filter(p -> p.firstName.contains("L")).collect(Collectors.toList());
		for(Person p : filterred3) {
			System.out.println(p.age);
		}
		
		System.out.println("Part 4: ");
		List<Person> filterred4=aPersons.stream()
				.filter(p -> p.firstName.contains("L")).collect(Collectors.toList());
		for(Person p : filterred4) {
			System.out.println(p.age);
		}
		
		List<Dog> aDogs = new ArrayList<Dog>();
		aDogs.add(new Dog(1,"N1","b1",60));
		aDogs.add(new Dog(2,"N2","Boxer",80));
		aDogs.add(new Dog(3,"N3","b3",20));

		System.out.println("Part 6: Dog weight >0 <100");
		List<Dog> filterred6=aDogs.stream()
				.filter(p -> p.weight>0).filter(p -> p.weight<100).collect(Collectors.toList());
		for(Dog p : filterred6) {
			System.out.println(p.name);
		}
		
		System.out.println("Part 7: breed=='Boxer'");
		List<Dog> filterred7=aDogs.stream()
				.filter(p -> p.breed=="Boxer").collect(Collectors.toList());
		for(Dog p : filterred7) {
			System.out.println(p.name);
		}
	}
}