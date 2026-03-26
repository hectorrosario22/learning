import { computed, Injectable } from '@angular/core';
import { MOCK_RECIPES } from './mock-recipes';

@Injectable({
  providedIn: 'root',
})
export class RecipeService {
  readonly recipes = computed(() => MOCK_RECIPES);
}
