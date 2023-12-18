import { useEffect, useState } from "react";
import "./index.css";
import VehicleSelection from "./components/vehicle-selection";
import { VehicleType } from "./types/vehicle-type";

function App() {
  const [vehicleType] = useState();

  const [passages, setPassages] = useState<Date[]>([]);
  const [selectedVehicle, setSelectedVehicle] = useState<VehicleType>("Car");

  useEffect(() => {
    setPassages([]);
  }, [vehicleType]);

  const [resultingPrice, setResultingPrice] = useState();

  const onGetTotalButtonClick = () => {
    const url = import.meta.env.VITE_API_URL;
    fetch(`${url}/toll`, {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(passages),
    })
      .then((response) => response.json())
      .then((data) => setResultingPrice(data.price));
  };

  return (
    <div className=" min-h-screen flex flex-col justify-center items-center">
      <VehicleSelection
        selectedVehicle={selectedVehicle}
        setSelectedVehicle={setSelectedVehicle}
      ></VehicleSelection>
      {resultingPrice}
      <button
        className="bg-blue-500 hover:bg-blue-400 duration:50 transition p-5 rounded text-white"
        onClick={onGetTotalButtonClick}
      >
        Get total
      </button>
    </div>
  );
}

export default App;
