import { Component, inject, signal } from '@angular/core';
import { FormBuilder, ReactiveFormsModule } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { Ingredient, RecipeModel } from '../models';
import { RecipeService } from '../recipe.service';
import { MatButtonModule } from '@angular/material/button';

@Component({
  selector: 'app-add-recipe',
  imports: [ReactiveFormsModule, RouterLink, MatButtonModule],
  templateUrl: './add-recipe.html',
  styleUrl: './add-recipe.css',
})
export class AddRecipe {
  private fb = inject(FormBuilder);
  private router = inject(Router);
  private recipeService = inject(RecipeService);

  protected ingredients = signal<Ingredient[]>([]);

  protected recipeForm = this.fb.group({
    id: [0],
    name: [''],
    description: [''],
    isFavorite: [false],
    imgUrl: [''],
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

  protected onSubmit() {
    const nextId = this.recipeService.getNextId();
    const formValue = this.recipeForm.value;
    const recipe = {
      ...formValue,
      id: formValue.id || nextId,
      ingredients: this.ingredients(),
    } as RecipeModel;
    this.recipeService.addRecipe(recipe);
    this.router.navigate(['/recipes']);
  }
}
