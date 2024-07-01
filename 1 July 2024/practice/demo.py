class Student:
    # Class attribute
    institution = 'University'

    def __init__(self, name, major):
        # Instance attributes
        self.name = name
        self.major = major

    def introduce(self):
        print(f'Hi, I am {self.name}, and I study {self.major}.')

class GraduateStudent(Student):
    def __init__(self, name, major, research_topic):
        super().__init__(name, major)
        self.research_topic = research_topic

    def present_research(self):
        print(f'I am {self.name}, and my research topic is {self.research_topic}.')

# Create an instance of Student
undergrad = Student('Alice', 'Computer Science')
undergrad.introduce() 

# Create an instance of GraduateStudent
grad_student = GraduateStudent('Bob', 'Physics', 'Quantum Mechanics')
grad_student.introduce() 
grad_student.present_research()  
