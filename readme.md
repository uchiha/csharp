[21052018]
- the purpose of this project is to gain more knowledge in C#
- on this initial commit, we are done until the 3rd set, classes and obj
- note how the author encouraged thinking what the responsibility of classes are. 
- GradeBook needs to take note of statistics, but that is a whole thing in itself, that is why creating a new class for that is better.
- GradeBook also needs to know that members of GradeStatistics are initialized, it can do it but the author thought of using the constructor of the GradeStatistics class to initialize the members. Check it out.
- another thing to note of is that the object does not contain the actual implememtation, speaking of that, the object of a class only contains a pointer to a memory location. That is why the code "GradeBook book2 = book;" both book2 and book had the same members. book2 copied the memory address book was referring to.

[22052018]
- today a test project was added by right clicking the solution and adding a test project.
- note that instead of MSTest, we've used nUnit for this one. 
- in order to refer to the classes in the CS project from the Test project, just right click the references section of the test project, instead of assemblies, select project and the CS project will be shown.
- a good concept on access modifier was noted here, "internal". Basically, classes cant be used as assembly references on other projects in C# because by default, all classes are internal. This means that, only classes that belong to the same project will be able to refer to that class.
- Another issue was, the method ComputeStatistics() returns an object of type GradeStatistics that is also internal. That was needed to be set to public as well. 
- Note, the issue was the ComputeStatistics() was accessible to anyone who has access to a GradeBook. But the same method returns GradeStatistics, that is why initially, there was an inconsistent accessibility error. It doesn't make sense to give access to a method that anyone can use if it returns a type that no one outside can see. 
- to solve this problem, one way is to set ComputeStatistics() to internal, that means anyone will be able to see this class, even outside assemblies, but only code in the same assembly will be able to see and invoke this method.

[23052018]
- C# the default is pass by value, meaning that when you call a method that takes a parameter BY DEFAULT the value in the parameter you pass will be copied into the variable that is a parameter to the method. And what you pass is always a copy, unless...
- the name of the test class does not matter except in the output of the test explorer. So changing the name of the class is ok unlike in Java.
- arrays are always a reference type.
- takeaway: ANY TYPE in C# is either reference or value types.
- delegates are a bit confusing. Scenario: something else in the application needs to know when the name of the grade book is changing. Maybe that thing is a data binding framework or whatever that needs to update the screen when a new Grade book name or whenever a grade book name changes. In our example, the only place or code that knows when the name is changing is in the setter of "Name". Delegate is like in JavaScript, where we set the method to a particular var. 
- on delegates again, on a UI analogy, lets say we are writing a class that's going to have a button associated with it because its a part of a UI, and our class the code inside will know when it is click, but how can our class announce to the rest of the world when that button is clicked? because chances are its not just me who is interested when that is clicked, we might need to tell other pieces of the app when that button is clicked. Ultimately, its done on events on top of delegates. :)

[24052018]
- at this point, the author discussed that the only need to make the code a legit event is to add the keyword event on the initialization of the delegate: public event NameChangedDelegate NameChanged;
- the effect is we will no longer be able to obliterate or override event subscriptions. We can only add or subtract events, and that is what we want in events because we dont want to mess up other subscriptions in our events.
- events in C# has a convention that 99.9% of devs follow wherein it passes along 2 parameters. The first is the sender of the event e.g. if in this case the gradebook announces that it will change its name, it should send itself too. 2nd param contains all the needed parameters about that event.
- we will build a custom class for this purpose.
- in C#, inside of every non-static method in a class or struct, there is an implicit variable called "this". And "this" will reference the object that I'm inside of. 
- Not all programming envs use events take note. This is common in some sort of desktop program that's a C# application that runs under windows or a mobile phone. Its common that the UI elements will use events to let our code know when something was clicked on or something was hovered over. 
- in terms of flow, I was confused with continue, here is an example
  foreach(int age in ages)
  {
     if(age ==2)
	 {
	    continue;
	 }
  }
  this basically means that in iteration, if 2 was encountered, don't do anything!
- on the throw episode:
  Unhandled Exception: System.ArgumentException: Name can't be null or empty!
   at CS.GradeBook.set_Name(String value) in C:\myworkspace\CS\CS\GradeBook.cs:line 32
   at CS.Program.Main(String[] args) in C:\myworkspace\CS\CS\Program.cs:line 24
  
  the author said that as the program is executing and you call a method that calls another method that calls another, there is a datastructure that is being build internally called a STACK. And with each method that you call something is pushed onto the stack. In this case, the exception was thrown in line 32 of GradeBook.cs, but its not that helpful here in terms of tracking. What's something that is helpful is usually further up the stack, and what's further is Program.cs on line 24. That is what caused this problem.
- on the "finally" episode, we were able to refactor the main method of the Program.cs file. Doing this requires highlighting the codes then pressing CTRL + .
  this will generate methods.
- on the Polymorphism, in C# it involved keywords virtual and override. Looking in our example wherein in the Program.cs class we have initialized ThrowAwayGradeBook object to a GradeBook type variable. When we call ComputeStatistics(), we saw that we are invoking the implementation in GradeBook, which is not what we want in this case. That's because the C# compiler without any other information is going to choose the method to invoke BASED ON THE TYPE OF THE VARIABLE. If we define a method or a property with a VIRTUAL keyword, then the C# compiler will generate code to invoke that method by looking at the type of OBJECT its working against at runtime. Without the VIRTUAL keyword, the method we invoke will be determined by the type of variable. Its the VIRTUAL keyword that gives us polymorphism because now, we can have variables that points to different objects and when we invoke methods or properties on those objects, they can all behave differently. NOTE classes that inherit from a base class can put an OVERRIDE keyword to make a method or property behave differently. 

[26052018]
- inheritance can be overrated techniques for code reuse. Fantastic code designs can be achieved with polymorph which requires some inheritance. Careful though, inheritance binds 2 classes together in a relationship that can't be broken.
- Maybe for application development, inheritance can make software harder to change and understand. To reduce rigidity of inheritance, you can use abstract classes and interfaces.
- Abstract classes can't be instantiated because it ain't fully implemented. Concrete types can be instantiated. The usefulness of abstract types can be identified because of polymorphism!
- in our gradebook, a scenario can happen where the change requests are so much. The org has identified a lot of different uses for a gradebook. A lot of different ways to compute stats, different way to store grades. Can be an xml file or through a database. They may want other nice things like report cards and or dashboards. 
- at this point, gradebook.cs is getting strained. Its not fulfilling the need of those other gradebook types. 
- at this point, we need a general case of more generic type of tracking. This being said, we need to create a more pure type of gradebook. A type that says the things we need to do without defining the implementation. That is an abstract class.
- as changes were made on GradeBook as related to GradeTracker, ultimately, the purpose is so that we can work with variables of type GradeTracker, in a place like the general Program.cs AND NOT WORRY about the specific type of GradeTracker that we are working on. Just like GradeBook and ThrowAwayGradeBook, but now we introduced a type with even fewer implememtation details. 
- interface is a type in the .NET framework. Just like class, struct and delegate keywords. Its special because it can never contain any implementation.
- when an interface is defined, we're defining an API for an object, that is any object that implements an interface is guaranteed to have the members described by the interface. 
- the huge difference between an interface and an abstract class is that when we define a class, we can only inherit from a single base class. BUT we can implement as many interface as we want. Interface is the ultimate abstraction, because it allows you to define the API your software needs, without defining any of the implementation details. Any class or struct can implement an interface, making it really flexible. 
- the author generally favors interfaces because in his experience he never looked at an interface and wished that it was an abstract class. However, he saw some abstract classes that should have been interfaces. Because abstract classes can still be rigid and make for a complicated inheritance tree. 
- using VS, at the Program.cs, GradeTracker was renamed to IGradeTracker then CTRL + . was done. Interface was generated in a new file without any members.
- working with interfaces increases the flexibility of the software. In the Program.cs case, we can get back at any object but it should be generally implementing the interface. Working with interfaces also enables us to work with a wide variety of objects.
- lets say in Program.cs, in the method WriteResults, we also wanted to print out the individual grades. SO we'll do a foreach statement. 
  foreach (float grade in book)
  {
       Console.WriteLine(grade);
  }
  at this point, the compiler will give an error because "book" can't be used on foreach. Can't iterate with it. Technically speaking, an object that implements IGradeTracker (book in this instance) is not guaranteed to have a public method GetEnumerator. At the lowest level, the object needs that method to be enumerable.
- its more common if we have a type that explicitly wants to be enumerable, we'll say that that type inherits from IEnumerable interface. 
- so IGradeTracker was changed to implement IEnumerable:
  -----> "internal interface IGradeTracker : IEnumerable"
- this results as, in Program.cs, "book" no longer has that error. :) The reason is, due to our changes, that guarantees that anything that implements an IGradeTracker is guaranteed to have GetEnumerator.
- the issue now is when we build, GradeTracker.cs will have an issue: "Error	CS0535	'GradeTracker' does not implement interface member 'IEnumerable.GetEnumerator()'"
- our abstract base class GradeTracker that implements IGradeTracker does not have a definition for "GetEnumerator()" This happened because we made IGradeTracker implement IEnumerable, that demands GetEnumerator() to be implemented. Checking IEnumerable with F12:
  namespace System.Collections
  {
		[ComVisible(true)]
		[Guid("496B0ABE-CDEE-11d3-88E8-00902754C43A")]
		public interface IEnumerable
		{
			IEnumerator GetEnumerator();
		}
  }
  ==> this means that we need to implement GetEnumerator() that returns another interface that is IEnumerator, something that implements that knows how to step through a collection one object at a time. This is an extremely powerful interface definition because we can hide all sorts of work behind an IEnumerable and IEnumerator.
- we need to guarantee that GradeTracker implements the interface:
  -----> "public IEnumerator GetEnumerator();"
- the problem is that GradeTracker does not know how to enumerate that grades that it holds. SO instead of that we need to declare it abstract:
  -----> "public abstract IEnumerator GetEnumerator();"
  AND this should be ok because in the perspective of GradeTracker, as designed, we don't know where the grades are stored. Are they in memory in a List, database, behind service call?
- now, the problem is that if we build:
  -----> "Error	CS0534	'GradeBook' does not implement inherited abstract member 'GradeTracker.GetEnumerator()'"
- the problem was pushed up one class, to GradeBook and we need to implement this now because GradeBook is not an abstract class. Fortunately: 
  -----> "protected List<float> grades;"
  we have this in GradeBook and a List is something that is also an IEnumerable. All collection classes in .NET implement the IEnumerable interface. Thus:
  public override IEnumerator GetEnumerator()
  {
       return grades.GetEnumerator();
  }
- THIS IS THE GREAT ADVANTAGE of interfaces wherein, we build powerful abstractions and hide complexities behind simple polymorph.