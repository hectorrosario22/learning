import { Component, computed, inject, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RecipeService } from '../recipe.service';
import { RouterLink } from '@angular/router';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';

@Component({
  selector: 'app-recipe-list',
  imports: [FormsModule, RouterLink, MatCardModule, MatIconModule, MatButtonModule],
  templateUrl: './recipe-list.html',
  styleUrl: './recipe-list.css',
})
export class RecipeList {
  protected readonly recipeService = inject(RecipeService);
  protected readonly searchTerm = signal('');
  protected readonly recipes = computed(() =>
    this.recipeService
      .recipes()
      .filter((recipe) => recipe.name.toLowerCase().includes(this.searchTerm().toLowerCase())),
  );
}
