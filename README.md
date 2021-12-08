## Settings Layers
The extension introduces several settings layers:
* CodeStyle
* CodeInspection
* FileLayout
* LiveTemplates
* UserDictionary

### CodeStyle Settings
This settings layer introduces standardised code style settings.

### CodeInspection Settings
This settings layer configures some of the ReSharper inspection settings.

### FileLayout Settings
This settings layer standardises the order of the FileLayout and creates  the RacingPoint Cleanup setting.
Clean-up can be executed using `Ctrl+E,C` and selecting RacingPoint Cleanup.

### LiveTemplates Settings
This settings layer adds LiveTemplates which are Intended to simplify repetitive tasks.

> *Note that elements inside `$` symbols are tokenised, and may present a list of options or objects.*

#### Templates for Production Code
Shortcut | Description | Notes / Syntax
-------- | ----------- | --------------
`cr` | Standard copyright header | `// Copyright (c) MDIT Solutions Ltd $CREATED_YEAR$.`
`gn` | Guard IsNotNull | `Guard.IsNotNull($parameterName$, nameof($parameterName$));`
`no` | nameof | `nameof($argument$)`
`rg` | Region | `#region $Access $Member #endregion`

#### Templates for Documentation
Shortcut | Description | Notes / Syntax
-------- | ----------- | --------------
`anx` | Argument Exception Documentation | Inserts exception docs following an empty triple-slash<br/>` <exception cref="System.$ArgumentNull$Exception">`<br/>`/// Thrown when <paramref name="$arg$"/> is $IsNull$.`<br/>`/// </exception>`
`cc` | Standard constructor documentation | `Initializes a new instance of the <see cref="$Class$"/> class.`
`inh` | Inheritdoc | `/// <inheritdoc/>`
`noop` | Standard documentation for a no-op method | `The default implementation is a no-op.`
`opr` | Adds documentation for an `or` clause, useful after using `anx` | `or <paramref name="$arg$"/>`
`pr` | Parameter reference | `<paramref name="$arg$"/>`
`seef` | See False Keyword | `<see langword="false"/>`
`seet` | See True Keyword | `<see langword="true"/>`
`seen` | See Null Keyword | `<see langword="null"/>`
`tprm` | Type parameter documentation | `/// <typeparam name="$T$">The type of <paramref name="$param$"/></typeparam>`

#### Templates for Test Code
Shortcut | Description | Notes / Syntax
-------- | ----------- | --------------
`amd` | [AutoMoqData] attribute | `[AutoMoqData]`
`amdc` | [AutoMoqData] attribute with customization | `[AutoMoqData(typeof($Customization$))]`
`ase` | General Assertion | `Assert.$Equal$($expected$.$Property$, $actual$.$Property$);`
`asx` | Exception Assertion | `Assert.Throws<$ExceptionType$Exception>(() => );`
`bcd` | Boolean Class Data Provider | `[Theory]`<br/>`[ClassData(typeof(BooleanClassDataProvider))]`
`ecd` | Enum Class Data Provider | `[Theory]`<br/>`[ClassData(EnumClassDataProvider<$EnumType$>))]`
`il` | Inline Data Attribute | `[InlineData($value$)]`
`ta` | Theory | `[Theory]`
`tc` | Skeleton code for a test class | Use in an empty .cs file to insert a skeleton test class including constructor initialisation and null argument tests.
`tctor` | Inserts a constructor test | `[Fact]`<br/>`public void Ctor_CorrectlyInitializesMembers()`<br/>`{ AutoAssert.ConstructorInitializesMembers<$Class$>(); }`
`tcx` | Inserts a null constructor arguments test | `[Fact]`<br/>`public void Ctors_WhenArgumentsNull_Throw()`<br/>`{ AutoAssert.ThrowsIfConstructorArgumentsNull<$Class$>()); }`
`tcmx` | Inserts constructor and method argument null tests | `[Fact]`<br/>`public void Ctors_WhenArgumentsNull_Throw()`<br/>`{ AutoAssert.ThrowsIfConstructorArgumentsNull<$Class$>()); }`<br/><br/>`[Theory]`<br/>`[ClassData(typeof(MethodInfoClassDataProvider<$Class$>))]`<br/>`public void Methods_WhenArgumentsNull_Throw(MethodInfo method)`<br/>`{ AutoAssert.ThrowsIfMethodArgumentsNull(method); }`
`tmx` | Inserts a null method arguments test | `[Theory]`<br/>`[ClassData(typeof(MethodInfoClassDataProvider<$Class$>))]`<br/>`public void Methods_WhenArgumentsNull_Throw(MethodInfo method)`<br/>`{ AutoAssert.ThrowsIfMethodArgumentsNull(method); }`
`tmsx` | Inserts a null method arguments test and a class<br/>data provider for testing a static class | `[Theory]`<br/>`[ClassData(typeof($Class$MethodProvider))]`<br/>`public void Methods_WhenArgumentsNull_Throw(MethodInfo method)`<br/>`{ AutoAssert.ThrowsIfMethodArgumentsNull(method); }`<br/><br/>`private class $Class$MethodProvider : MethodInfoClassDataProvider`<br/>`{ public $Class$MethodProvider() : base(typeof($Class$)) {} }`
`teq` | Skeleton code for an equality test | Inserts a `ImplementsEqualityContract()` test
`tm` | Skeleton code for a test | Inserts a new test with tokenised `public void $Method$_$Action$_$Expectation$()` name