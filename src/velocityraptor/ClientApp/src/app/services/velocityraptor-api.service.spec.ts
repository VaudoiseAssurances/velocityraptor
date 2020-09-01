import { VelocityraptorApiService } from "./velocityraptor-api.service";
import { TestBed } from "@angular/core/testing";

describe("VelocityraptorApiService", () => {

  let service: VelocityraptorApiService;
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [
        VelocityraptorApiService
      ]
    });
    service = TestBed.get(VelocityraptorApiService);

  });

  it("should be able to create service instance", () => {
    expect(service).toBeDefined();
  });

});
