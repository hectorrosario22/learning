import { Component, computed, inject, signal } from '@angular/core';
import { RecipeModel } from '../models';
import { ActivatedRoute, Router } from '@angular/router';
import { RecipeService } from '../recipe.service';

@Component({
  selector: 'app-recipe-detail',
  imports: [],
  templateUrl: './recipe-detail.html',
  styleUrl: './recipe-detail.css',
})
export class RecipeDetail {
  protected readonly router = inject(Router);
  protected readonly currentRoute = inject(ActivatedRoute);
  protected readonly recipeService = inject(RecipeService);
  protected readonly recipe = signal<RecipeModel>({} as RecipeModel);
  protected readonly servings = signal(1);
  protected readonly ingredients = computed(() => {
    const currentRecipe = this.recipe();
    const currentServings = this.servings();
    return currentRecipe.ingredients.map((ingredient) => ({
      ...ingredient,
      quantity: ingredient.quantity * currentServings,
    }));
  });

  constructor() {
    const id = Number(this.currentRoute.snapshot.paramMap.get('id'));
    if (isNaN(id)) {
      this.router.navigate(['/recipes']);
      return;
    }

    const recipe = this.recipeService.recipes().find((r) => r.id === id);
    if (!recipe) {
      this.router.navigate(['/recipes']);
      return;
    }

    this.recipe.set(recipe);
  }

  protected updateServings(operation: 'increase' | 'decrease'): void {
    if (operation === 'increase') {
      this.servings.update((value) => value + 1);
    } else {
      this.servings.update((value) => Math.max(1, value - 1));
    }
  }
}
