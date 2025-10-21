namespace stack_overflow.Core.Exceptions;

public class UserAlreadyExistsException(string email) : Exception($"User with email {email} is already registered");