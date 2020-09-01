import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { switchMap, map, mergeMap } from 'rxjs/operators';
import { VelocityraptorApiService, Sprint } from '../services/velocityraptor-api.service';

@Component({
  selector: 'app-sprint',
  templateUrl: './sprint.component.html',
  styleUrls: ['./sprint.component.scss']
})

export class SprintComponent implements OnInit {
  sprintId: string;
  public sprint: Sprint = {
  } as Sprint;
  accomplishedPoints: number;
  productId: string;

  constructor(private route: ActivatedRoute, private service: VelocityraptorApiService) { }

  ngOnInit() {
    this.route.paramMap
    .pipe(
      mergeMap(params => {
        this.sprintId = params.get('sprintId');
        this.productId = params.get('productId');
        return this.service.getSprint(this.productId, this.sprintId); // http request
      })
    )
    .subscribe(s => {
      this.accomplishedPoints = s.achievedPoints;
      this.sprint = s;
    });
  }

  public updateAccomplishedPoints(accomplishedPoints: number) {
    this.service.setAccomplishedPoints(this.productId, this.sprintId, accomplishedPoints)
      .subscribe(o => console.log('done'));
  }
}
