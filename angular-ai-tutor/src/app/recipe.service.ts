import { computed, Injectable } from '@angular/core';
import { MOCK_RECIPES } from './mock-recipes';
import { RecipeModel } from './models';

@Injectable({
  providedIn: 'root',
})
export class RecipeService {
  readonly recipes = computed(() => MOCK_RECIPES);

  addRecipe(recipe: RecipeModel): void {
    MOCK_RECIPES.push(recipe);
  }

  getNextId(): number {
    return MOCK_RECIPES.length > 0 ? Math.max(...MOCK_RECIPES.map((r) => r.id)) + 1 : 1;
  }
}
