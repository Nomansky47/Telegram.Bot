using Scriban;
using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Text;

namespace EnumSerializer.Generator;

public static class SourceGenerationHelper
{
    private const string Header = @"//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by the EnumSerializer.Generator source generator
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

#nullable enable
";

    public const string EnumConverter = Header + @"
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Runtime.CompilerServices;

namespace Telegram.Bot.Converters;

internal abstract class EnumConverter<TEnum> : JsonConverter<TEnum>
    where TEnum : Enum
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected abstract TEnum GetEnumValue(string value);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected abstract string GetStringValue(TEnum value);

    public override void WriteJson(JsonWriter writer, TEnum value, JsonSerializer serializer) =>
        writer.WriteValue(GetStringValue(value));

    public override TEnum ReadJson(
        JsonReader reader,
        Type objectType,
        TEnum existingValue,
        bool hasExistingValue,
        JsonSerializer serializer
    ) =>
        GetEnumValue(JToken.ReadFrom(reader).Value<string>());
}
";

    public static string GenerateConverterClass(StringBuilder sb, EnumInfo enumToGenerate)
    {
        sb.Append(Header);
        sb.Append(@"
using System.Collections.Generic;
using Telegram.Bot.Converters;");

        if (!string.IsNullOrEmpty(enumToGenerate.Namespace))
        {
            sb.Append(@"

namespace ").Append(enumToGenerate.Namespace).Append(';');
        }

        sb.Append(@"

").Append("internal partial class ").Append(enumToGenerate.Name).Append("Converter").Append(": EnumConverter<").Append(enumToGenerate.Name).Append('>').Append(@"
{
    static readonly IReadOnlyDictionary<string, ").Append(enumToGenerate.Name).Append(@"> StringToEnum =
        new Dictionary<string, ").Append(enumToGenerate.Name).Append(@">(").Append(enumToGenerate.Members.Count).Append(@")
        {");
        foreach (var enumMember in enumToGenerate.Members)
        {
            sb.Append(@"
            {""").Append(enumMember.Value.MemberName).Append(@""", ").Append(enumToGenerate.Name).Append('.').Append(enumMember.Key).Append("},");
        }
        sb.Append(@"
        };

    static readonly IReadOnlyDictionary<").Append(enumToGenerate.Name).Append(@", string> EnumToString =
        new Dictionary<").Append(enumToGenerate.Name).Append(@", string>(").Append(enumToGenerate.Members.Count).Append(@")
        {");
        if (!enumToGenerate.Members.Any(n => string.Equals(n.Key, "unknown", StringComparison.OrdinalIgnoreCase)))
        {
            sb.Append(@"
            { 0, ""unknown"" },");
        }

        foreach (var enumMember in enumToGenerate.Members)
        {
            sb.Append(@"
            {").Append(enumToGenerate.Name).Append('.').Append(enumMember.Key).Append(@", """).Append(enumMember.Value.MemberName).Append(@"""},");
        }
        sb.Append(@"
        };

    protected override ").Append(enumToGenerate.Name).Append(@" GetEnumValue(string value) =>
        StringToEnum.TryGetValue(value, out var enumValue)
            ? enumValue
            : 0;

    protected override string GetStringValue(").Append(enumToGenerate.Name).Append(@" value) =>
        EnumToString.TryGetValue(value, out var stringValue)
            ? stringValue
            : ""unknown"";

    // public ").Append(enumToGenerate.Name).Append(@" GetEnumValue_(string value) => GetEnumValue(value);
    // public string GetStringValue_(").Append(enumToGenerate.Name).Append(@" value) => GetStringValue(value);
}");

        return sb.ToString();
    }

    public static string GenerateConverterClass2(StringBuilder sb, EnumInfo enumToGenerate)
    {
        sb.Append(Header);
        sb.Append(@"
using Telegram.Bot.Converters;");

        if (!string.IsNullOrEmpty(enumToGenerate.Namespace))
        {
            sb.Append(@"

namespace ").Append(enumToGenerate.Namespace).Append(';');
        }

        sb.Append(@"

").Append("internal partial class ").Append(enumToGenerate.Name).Append("Converter2").Append(": EnumConverter<").Append(enumToGenerate.Name).Append('>').Append(@"
{
    protected override ").Append(enumToGenerate.Name).Append(@" GetEnumValue(string value) =>
        value switch
        {");
        foreach (var enumMember in enumToGenerate.Members)
        {
            sb.Append(@"
            """).Append(enumMember.Value.MemberName).Append(@""" => ").Append(enumToGenerate.Name).Append('.').Append(enumMember.Key).Append(',');
        }
        sb.Append(@"
            _ => 0,
        };

    protected override string GetStringValue(").Append(enumToGenerate.Name).Append(@" value) =>
        value switch
        {");
        foreach (var enumMember in enumToGenerate.Members)
        {
            sb.Append(@"
            ").Append(enumToGenerate.Name).Append('.').Append(enumMember.Key).Append(@" => """).Append(enumMember.Value.MemberName).Append(@""",");
        }
        sb.Append(@"
            _ => ""unknown"",
        };

    // public ").Append(enumToGenerate.Name).Append(@" GetEnumValue_(string value) => GetEnumValue(value);
    // public string GetStringValue_(").Append(enumToGenerate.Name).Append(@" value) => GetStringValue(value);
}");

        return sb.ToString();
    }

    public static string GenerateConverterClass3(EnumInfo enumToGenerate)
    {
        var template = Template.Parse(@"
{{ header }}

using Telegram.Bot.Converters;

{{~ if enum_namespace ~}}
namespace {{ enum_namespace }};
{{~ end ~}}

internal partial class {{ enum_name }}Converter3 : EnumConverter<{{ enum_name }}>
{
    protected override {{ enum_name }} GetEnumValue(string value) =>
        value switch
        {
        {{~ for enum_member in enum_members ~}}
            ""{{ enum_member.value.member_name }}"" => {{ enum_name }}.{{ enum_member.key }},
        {{~ end ~}}
            _ => 0,
        };

    protected override string GetStringValue({{ enum_name }} value) =>
        value switch
        {
        {{~ for enum_member in enum_members ~}}
            {{ enum_name }}.{{enum_member.key}} => ""{{ enum_member.value.member_name }}"",
        {{~ end ~}}
            _ => ""unknown"",
        };

    // public {{ enum_name }} GetEnumValue_(string value) => GetEnumValue(value);
    // public string GetStringValue_({{ enum_name }} value) => GetStringValue(value);
}");
        var result = template.Render(new
        {
            EnumNamespace = enumToGenerate.Namespace,
            EnumName = enumToGenerate.Name,
            EnumMembers = enumToGenerate.Members
        });

        return result;
    }
}
