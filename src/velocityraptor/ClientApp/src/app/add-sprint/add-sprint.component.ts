import { VelocityraptorApiService } from './../services/velocityraptor-api.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-add-sprint',
  templateUrl: './add-sprint.component.html',
  styleUrls: ['./add-sprint.component.scss']
})

export class AddSprintComponent implements OnInit {

  private newSprintForm: FormGroup;

  private addDeveloperAvailability(): FormGroup {
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
      developerAvailabilities: this.formBuilder.array([this.addDeveloperAvailability()])
    });
  }

  ngOnInit() {

  }

  onSubmit(sprint) {
    // Process checkout data here

    this.newSprintForm.reset();

    console.warn('Creating sprint: ', sprint);
  }
}
