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
  sprint: Sprint;

  constructor(private route: ActivatedRoute, private service: VelocityraptorApiService) { }

  ngOnInit() {
    this.route.paramMap
    .pipe(
      mergeMap(params => {
        const sprintId = params.get('sprintId');
        const productId = params.get('productId');
        return this.service.getSprint(productId, sprintId); // http request
      })
    )
    .subscribe(o => console.log(o));
  }
}
