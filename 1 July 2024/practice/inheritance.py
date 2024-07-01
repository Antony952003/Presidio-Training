class Parent1:
    def __init__(self):
        self.value1 = "Parent1 value"
    
    def method(self):
        print("Method from Parent1")

class Parent2:
    def __init__(self):
        self.value2 = "Parent2 value"
        
    def method(self):
        print("Method from Parent2")

class Child(Parent1, Parent2):
    def __init__(self):
        Parent1.__init__(self)
        Parent2.__init__(self)
        self.value3 = "Child value"

    # def method(self):
    #     print("Method from Child")

# Creating an instance of Child
c = Child()
c.method() #This will call the child class method
print(c.value1)  
print(c.value2)  
print(c.value3)
