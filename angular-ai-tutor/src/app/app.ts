import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { RecipeList } from "./recipe-list/recipe-list";

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, RecipeList],
  templateUrl: './app.html',
  styleUrl: './app.css',
})
export class App {
  protected readonly appTitle = signal('Smart Recipe App');
}
