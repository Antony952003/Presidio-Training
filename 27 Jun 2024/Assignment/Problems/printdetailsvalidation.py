import re
from datetime import datetime

def validate_name(name):
    if name.isalpha():
        return True
    print("Invalid name. Please enter only alphabetic characters.")
    return False

def validate_age(age):
    if age.isdigit() and int(age) > 0:
        return True
    print("Invalid age. Please enter a positive integer.")
    return False

def validate_date_of_birth(date_of_birth):
    try:
        datetime.strptime(date_of_birth, "%d/%m/%Y")
        birth_date = datetime.strptime(date_of_birth, "%d/%m/%Y")
        current_date = datetime.now()
        diff_of_days = current_date - birth_date
        print(diff_of_days , type(diff_of_days))
        return diff_of_days
    except ValueError:
        print("Invalid date of birth. Please enter in DD/MM/YYYY format.")
        return False

def validate_phone(phone):
    if phone.isdigit() and len(phone) == 10:
        return True
    print("Invalid phone number. Please enter a 10-digit phone number.")
    return False

def get_valid_input(prompt, validation_function):
    while True:
        user_input = input(prompt)
        if validation_function(user_input):
            return user_input

name = get_valid_input("Enter your Name: ", validate_name)
age = get_valid_input("Enter your Age: ", validate_age)
date_of_birth = get_valid_input("Enter your Date of Birth (DD/MM/YYYY): ", validate_date_of_birth)
phone = get_valid_input("Enter your Phone Number: ", validate_phone)

print(f"\nValidated Information:\nName: {name}\nAge: {age}\nDate of Birth: {date_of_birth}\nPhone Number: {phone}")
