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
    <div className="flex flex-col">
      <label htmlFor="vehicle-select" className="text-left">
        Select vehicle type:
      </label>
      <select
        id="vehicle-select"
        value={selectedVehicle}
        onChange={onSelectionChange}
        className="py-5 px-2 border-blue-400 rounded border-4 outline-transparent"
      >
        {vehicleTypes.map((type) => (
          <option key={type} value={type}>
            {type}
          </option>
        ))}
      </select>
    </div>
  );
};

export default VehicleSelection;
