using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using YamlDotNet.Serialization;

namespace Prompton.Yaml;

public class OrderedTypeInspector : ITypeInspector
{
    private readonly ITypeInspector _innerTypeInspector;

    public OrderedTypeInspector(ITypeInspector innerTypeInspector)
    {
        _innerTypeInspector = innerTypeInspector;
    }

    public IEnumerable<IPropertyDescriptor> GetProperties(Type type, object container)
    {
        var properties = _innerTypeInspector.GetProperties(type, container);
        var idProp = properties.FirstOrDefault(x => x.Name == "StepId");
        if (idProp == null)
            return properties;
        return properties.Where(x => x.Name != "StepId").Prepend(idProp);
    }

    public IPropertyDescriptor GetProperty(Type type, object container, string name, [MaybeNullWhen(true)] bool ignoreUnmatched)
    {
        return _innerTypeInspector.GetProperty(type, container, name, ignoreUnmatched);
    }
}
