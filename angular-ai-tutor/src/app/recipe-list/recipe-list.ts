import { Component, computed, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MOCK_RECIPES } from '../mock-recipes';
import { RecipeModel } from '../models';
import { RecipeDetail } from '../recipe-detail/recipe-detail';

@Component({
  selector: 'app-recipe-list',
  imports: [FormsModule, RecipeDetail],
  templateUrl: './recipe-list.html',
  styleUrl: './recipe-list.css',
})
export class RecipeList {
  protected readonly currentRecipe = signal<RecipeModel>(MOCK_RECIPES[0]);
  protected readonly searchTerm = signal('');
  protected readonly recipes = computed(() =>
    MOCK_RECIPES.filter((recipe) =>
      recipe.name.toLowerCase().includes(this.searchTerm().toLowerCase()),
    ),
  );

  protected switchToRecipe(recipe: RecipeModel): void {
    this.currentRecipe.set(recipe);
  }
}
