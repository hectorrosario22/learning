import { Component, computed, input, signal } from '@angular/core';
import { RecipeModel } from '../models';

@Component({
  selector: 'app-recipe-detail',
  imports: [],
  templateUrl: './recipe-detail.html',
  styleUrl: './recipe-detail.css',
})
export class RecipeDetail {
  readonly recipe = input.required<RecipeModel>();
  protected readonly servings = signal(1);
  protected readonly ingredients = computed(() => {
    const currentRecipe = this.recipe();
    const currentServings = this.servings();
    return currentRecipe.ingredients.map((ingredient) => ({
      ...ingredient,
      quantity: ingredient.quantity * currentServings,
    }));
  });

  protected updateServings(operation: 'increase' | 'decrease'): void {
    if (operation === 'increase') {
      this.servings.update((value) => value + 1);
    } else {
      this.servings.update((value) => Math.max(1, value - 1));
    }
  }
}
