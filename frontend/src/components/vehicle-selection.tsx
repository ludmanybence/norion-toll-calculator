import { ChangeEvent } from "react";
import { VehicleType, vehicleTypes } from "../types/vehicle-type";

interface Props {
  selectedVehicle: VehicleType;
  setSelectedVehicle: React.Dispatch<React.SetStateAction<VehicleType>>;
}

const VehicleSelection = ({ selectedVehicle, setSelectedVehicle }: Props) => {
  const onSelectionChange = (e: ChangeEvent<HTMLSelectElement>) => {
    setSelectedVehicle(e.target.value as VehicleType);
  };

  return (
    <select value={selectedVehicle} onChange={onSelectionChange}>
      {vehicleTypes.map((type) => (
        <option value={type}>{type}</option>
      ))}
    </select>
  );
};

export default VehicleSelection;
