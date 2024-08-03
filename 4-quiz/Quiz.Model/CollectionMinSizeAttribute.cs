using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace Quiz.Model;

public class CollectionMinSizeAttribute<T> : ValidationAttribute
{
    private readonly int _minSize;

    public CollectionMinSizeAttribute(int minSize)
    {
        _minSize = minSize;
    }

    public override bool RequiresValidationContext => false;

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is not IEnumerable<T> enumerable)
        {
            return new ValidationResult($"The value does not implement {typeof(IEnumerable<T>).Name}");
        }

        if (enumerable.Count() < _minSize)
        {
            return new ValidationResult($"The collection must have at least {_minSize} items");
        }

        return null;
    }
}