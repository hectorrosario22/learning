import { Component, computed, inject, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RecipeModel } from '../models';
import { RecipeDetail } from '../recipe-detail/recipe-detail';
import { RecipeService } from '../recipe.service';

@Component({
  selector: 'app-recipe-list',
  imports: [FormsModule, RecipeDetail],
  templateUrl: './recipe-list.html',
  styleUrl: './recipe-list.css',
})
export class RecipeList {
  protected readonly recipeService = inject(RecipeService);
  protected readonly currentRecipe = signal<RecipeModel>(this.recipeService.recipes()[0]);
  protected readonly searchTerm = signal('');
  protected readonly recipes = computed(() =>
    this.recipeService
      .recipes()
      .filter((recipe) => recipe.name.toLowerCase().includes(this.searchTerm().toLowerCase())),
  );

  protected switchToRecipe(recipe: RecipeModel): void {
    this.currentRecipe.set(recipe);
  }
}
