import http from "k6/http";
import { check, sleep } from "k6";

export const options = {
  scenarios: {
    spike_test: {
      executor: "ramping-vus",
      exec: "spikeLoad",
      startVUs: 0,
      stages: [
        { duration: "5s", target: 10 },
        { duration: "5s", target: 100 }, // spike!
        { duration: "10s", target: 100 },
        { duration: "5s", target: 10 },
        { duration: "5s", target: 0 },
      ],
    },
    stress_test: {
      executor: "ramping-vus",
      exec: "stressLoad",
      startTime: "30s", // empieza después del spike
      stages: [
        { duration: "10s", target: 20 },
        { duration: "10s", target: 50 },
        { duration: "10s", target: 100 },
        { duration: "10s", target: 200 },
        { duration: "10s", target: 300 },
        { duration: "10s", target: 0 },
      ],
    },
    soak_test: {
      executor: "constant-vus",
      exec: "soakLoad",
      startTime: "1m30s", // empieza después del stress
      vus: 50,
      duration: "5m",
    },
  },
};

export function spikeLoad() {
  const res = http.get("http://localhost:5000/api/products");
  check(res, { "status is 200": (r) => r.status === 200 });
  sleep(1);
}

export function stressLoad() {
  const res = http.get("http://localhost:5000/api/products");
  check(res, { "status is 200": (r) => r.status === 200 });
  sleep(0.5);
}

export function soakLoad() {
  const res = http.get("http://localhost:5000/api/products");
  check(res, { "status is 200": (r) => r.status === 200 });
  sleep(2);
}
