export const vehicleTypes = [
  "Car",
  "Motorbike",
  "Tractor",
  "Emergency",
  "Diplomat",
  "Foreign",
  "Military",
] as const;

export type VehicleType = (typeof vehicleTypes)[number];
