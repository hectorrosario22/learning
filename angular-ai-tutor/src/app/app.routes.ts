import { Routes } from '@angular/router';
import { RecipeList } from './recipe-list/recipe-list';
import { RecipeDetail } from './recipe-detail/recipe-detail';
import { Home } from './home/home';
import { AddRecipe } from './add-recipe/add-recipe';

export const routes: Routes = [
  {
    path: '',
    component: Home,
  },
  {
    path: 'recipes',
    component: RecipeList,
  },
  {
    path: 'recipes/:id',
    component: RecipeDetail,
  },
  {
    path: 'add-recipe',
    component: AddRecipe,
  },
];
