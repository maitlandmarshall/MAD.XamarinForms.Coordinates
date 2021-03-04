# MAD.XamarinForms.Coordinates
This library allows you to convert between view coordinate systems.

```c#
// A UI has been setup somewhere, these are just placeholders for example
var grid = new Grid();
var button = new Button();
grid.Children.Add(button);

var coordinateService = new CoordinateService();

// Get where the button is relative to the grid's coordinate system
var coordinates = coordinateService.ConvertPointToView(button, Point.Zero, grid);
```
