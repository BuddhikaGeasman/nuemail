# HTML email template creator

- [Purpose](#purpose)
- [Objectives](#objectives)
- [HTML Email Characteristics](#characteristics)

## Purpose
- Create a platform for users to create email news letters.
- A software program that allows easily customers can build, edit templates.

## Objectives
- Create fixed most generic email templates.
- Create responsive html emails.
- Remove bugs that can be occured during email distribution softwares; such as Lyris, mail cmmp.
- Able to test from Litmus or email on acid.
- Create customizable emails and html websites (per user web sites).
- Provide CSS options.

## HTML Email Characteristics
- `meta` tags `XTML Transitional`.
- Width of the email must be 600px.
- Using inline styles and making fixed styles in head tag.
- CSS options availability.
- Image responsiveness throughout tables.
- Providing guidelines on widths of tables.
- Using email boilerplate or ink.
- User interface access Dreamweaver options or browser compiling.

Main question to ask why this is better than DW or better options than DW or any other editors.
- This should provide main needs of a newsletter; such as buttons, images, etc.
- A person who does not know programming must be able to edit customize, create HTML emails.
- Customization should be very easy.
- This software must provide the user to create HTML web site with given components.
- Not supportive as an editor should be a key feature.
- Should be a small scale software.

Availability for js editing must be considered in future.

## Documentation

- Interface IHTag

```
public interface IHTag
{
	string CreateSTag(); 
	string CreateETag(); 
	string ToString(); 
 }
```
This interface gives the programmer a specific set of rules to follow when creating the HTMLTag class. Currently the class is implemented for XTML 1.0 tags only. Some tags could be as same as the HTML. CreateSTag creates the starting tag and returns the string value of the starting tag, CreateETag creates the ending tag and returns the string value. ToString returns the concatenation of two blocks.

- Interface ICSSScript

```
public interface ICSSScript
{
	string CreateCTags();
	void addParam(string param,string value);
 }
```

This interface gives the programmer the rules to implement a CSSScript class. The CSSScript class is implemented to only be non-nested styles.

- class HTag : IHTag
Following constructor creates a complete version of an HTML tag where `tag` is the tag name, `cname` is the css class, `style` is the inline css style and other html arguments and their values respectively. This throws the exception NArgumentsNValuesNotEqualException. Hence second and fourth also throw this Exception.

```
	private HTag(string tag, string cname, string style, string[] argz, string[] values)
```
Following other constructors create derrived versions of the above constructor.
```
	// Derrived constructor for style attribute
	public HTag(string tag, string style)
	// Derrived constructor for style sheets
	public HTag(string tag, string cname, string[] argz, string[] values)
	// Derrived constructor creates a basic tag ex: <html>;
	public HTag(string tag) : this(tag,null,null,null,null)
	// Derrived constructor for simple tags ex: <a alt=''>
	public HTag(string tag,string[] argz,string[] valz) : this(tag,null,null,argz,valz)
	// Implemented member functions CreateSTag(), CreateETag(), ToString()
```
- class CSSScript:ICSSScript
This constructor initialize the CSS class `classname` itself and the parameters can be added later.
```
	public CSSScript(string classname)
```
`addParam` adds CSS parameters inside the class `classname` defined earlier.
```
public void addParam(string param, string value)
```
Finally `CreateCTags` will generate the CSS class as a string object.
```
public string CreateCTags()
```
For the user convinience a constructor with three arguments is implemented which can be used to define CSS classes with one parameters.
```
	public CSSScript(string classname,string parameter,string value)
```
`ToString()` is overrided by the string returns by `CreateCTags()`.
- class HCode

The construction of the HCode object initialize the HCode object with <html></html> tags. The HCode uses a linked list to store the HTML texts. Simply `addHeadTag()` and `addBodyTag()` insert <head> and <body> tags respectively and also end both tags. Both throw AlreadyAddedException when someone try to add a tag already added. 
```
	// Insert a any tag inside the any tags
	public void addAnyTag(HTag tag, string startAfter)
	// Returns the complete HTML code stored in the linked list
	public string getHTMLCode()
```

