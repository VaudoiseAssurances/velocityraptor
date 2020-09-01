import { ActivatedRoute, Router } from '@angular/router';
import { VelocityraptorApiService } from './../services/velocityraptor-api.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormArray } from '@angular/forms';

@Component({
  selector: 'app-add-sprint',
  templateUrl: './add-sprint.component.html',
  styleUrls: ['./add-sprint.component.scss']
})

export class AddSprintComponent implements OnInit {

  private newSprintForm: FormGroup;
  developerAvailabilities: FormArray;
  private productId: string;

  private createDeveloperAvailability(): FormGroup {
    return this.formBuilder.group({
      developerId: '',
      availability: '',
    });
  }

  constructor(
    private client: VelocityraptorApiService,
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
  ) {
    this.newSprintForm = this.formBuilder.group({
      name: '',
      capacity: '',
      developerAvailabilities: this.formBuilder.array([this.createDeveloperAvailability()])
    });
  }

  ngOnInit() {
    this.route.paramMap.subscribe(o => this.productId = o.get('productId'));
  }

  addDeveloper() {
    this.developerAvailabilities = this.newSprintForm.get('developerAvailabilities') as FormArray;
    this.developerAvailabilities.push(this.createDeveloperAvailability());
  }

  onSubmit(sprint) {
    // Process checkout data here

    // this.newSprintForm.reset();

    this.client.createSprint(this.productId, sprint).subscribe(o => this.router.navigateByUrl('/products/'))
  }
}
