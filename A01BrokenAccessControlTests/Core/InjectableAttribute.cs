namespace A01BrokenAccessControlTests.Core;

public class InjectableAttribute : Attribute {
	public Type? Type { get; }
	public InjectableAttribute() { }

	public InjectableAttribute(Type type) {
		Type = type;
	}
}

public class InjectableAttribute<T> : InjectableAttribute {
	public InjectableAttribute() : base(typeof(T)) { }
}
