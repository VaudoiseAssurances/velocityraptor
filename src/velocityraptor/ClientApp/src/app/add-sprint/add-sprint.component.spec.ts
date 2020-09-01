import { NO_ERRORS_SCHEMA } from "@angular/core";
import { AddSprintComponent } from "./add-sprint.component";
import { ComponentFixture, TestBed } from "@angular/core/testing";

describe("AddSprintComponent", () => {

  let fixture: ComponentFixture<AddSprintComponent>;
  let component: AddSprintComponent;
  beforeEach(() => {
    TestBed.configureTestingModule({
      schemas: [NO_ERRORS_SCHEMA],
      providers: [
      ],
      declarations: [AddSprintComponent]
    });

    fixture = TestBed.createComponent(AddSprintComponent);
    component = fixture.componentInstance;

  });

  it("should be able to create component instance", () => {
    expect(component).toBeDefined();
  });
  
});
