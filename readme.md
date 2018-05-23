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