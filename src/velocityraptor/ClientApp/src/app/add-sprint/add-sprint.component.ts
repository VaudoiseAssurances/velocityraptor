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

  private createDeveloperAvailability(): FormGroup {
    return this.formBuilder.group({
      name: '',
      availability: '',
    });
  }

  constructor(
    private client: VelocityraptorApiService,
    private formBuilder: FormBuilder,
  ) {
    this.newSprintForm = this.formBuilder.group({
      name: '',
      capacity: '',
      developerAvailabilities: this.formBuilder.array([this.createDeveloperAvailability()])
    });
  }

  ngOnInit() {

  }

  addDeveloper() {
    this.developerAvailabilities = this.newSprintForm.get('developerAvailabilities') as FormArray;
    this.developerAvailabilities.push(this.createDeveloperAvailability());
  }

  onSubmit(sprint) {
    // Process checkout data here

    this.newSprintForm.reset();

    console.warn('Creating sprint: ', sprint);
  }
}
