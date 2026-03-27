import { Component, inject, signal } from '@angular/core';
import { form, FormField, required } from '@angular/forms/signals';
import { Router, RouterLink } from '@angular/router';
import { Ingredient, RecipeModel } from '../models';
import { RecipeService } from '../recipe.service';
import { MatButtonModule } from '@angular/material/button';

@Component({
  selector: 'app-add-recipe-signals',
  imports: [FormField, RouterLink, MatButtonModule],
  templateUrl: './add-recipe-signals.html',
  styleUrl: './add-recipe-signals.css',
})
export class AddRecipeSignals {
  private router = inject(Router);
  private recipeService = inject(RecipeService);

  protected ingredients = signal<Ingredient[]>([]);

  protected readonly recipeModel = signal({
    name: '',
    authorEmail: '',
    description: '',
    isFavorite: false,
    imgUrl: '',
  });
  protected readonly recipeForm = form(this.recipeModel, (schemaPath) => {
    required(schemaPath.name, { message: 'Name is required' });
    required(schemaPath.authorEmail, { message: 'Author email is required' });
    required(schemaPath.description, { message: 'Description is required' });
    required(schemaPath.imgUrl, { message: 'Image URL is required' });
  });

  protected addIngredient(
    nameInput: HTMLInputElement,
    quantityInput: HTMLInputElement,
    unitInput: HTMLInputElement,
  ) {
    const name = nameInput.value.trim();
    const quantity = parseFloat(quantityInput.value);
    const unit = unitInput.value.trim();

    if (name && !isNaN(quantity) && unit) {
      const newIngredient: Ingredient = { name, quantity, unit };
      this.ingredients.update((current) => [...current, newIngredient]);

      nameInput.value = '';
      quantityInput.value = '';
      unitInput.value = '';
      nameInput.focus();
    }
  }

  protected removeIngredient(index: number) {
    this.ingredients.update((current) => current.filter((_, i) => i !== index));
  }

  protected onSubmit(event: Event) {
    event.preventDefault();
    const nextId = this.recipeService.getNextId();
    const formValue = this.recipeModel();
    const recipe = {
      ...formValue,
      id: nextId,
      ingredients: this.ingredients(),
    } as RecipeModel;
    this.recipeService.addRecipe(recipe);
    this.router.navigate(['/recipes']);
  }
}
