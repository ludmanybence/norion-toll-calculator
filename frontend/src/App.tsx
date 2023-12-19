import { useEffect, useState } from "react";
import "./index.css";
import VehicleSelection from "./components/vehicle-selection";
import { VehicleType } from "./types/vehicle-type";
import PaymentResult from "./components/payment-result";
import PassagesList from "./components/passages-list";
import PassageForm from "./components/passage-form";

function App() {
  const [passages, setPassages] = useState<Date[]>([]);
  const [selectedVehicle, setSelectedVehicle] = useState<VehicleType>("Car");

  const [addingPassage, setAddingPassage] = useState<boolean>(false);

  const addPassage = (passage: Date) => {
    setPassages((passages) => [...passages, passage]);
  };

  useEffect(() => {
    setPassages([]);
  }, [selectedVehicle]);

  const [resultingPrice, setResultingPrice] = useState();

  const onGetTotalButtonClick = () => {
    const url = import.meta.env.VITE_API_URL;
    fetch(`${url}/toll`, {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify({vehicleType:selectedVehicle, passages:passages}),
    })
      .then((response) => response.json())
      .then((data) => setResultingPrice(data.price));
  };

  return (
    <div className=" min-h-screen flex flex-col justify-center items-center">
      <div className="w-[300px] flex flex-col items-center [&>*]:w-full">
        {addingPassage ? (
          <>
            <PassageForm
              addPassage={addPassage}
              onAdded={() => setAddingPassage(false)}
            />
            <button
              className="bg-slate-400 hover:bg-slate-300 duration:50 transition p-5 rounded text-white mt-5"
              onClick={() => setAddingPassage(false)}
            >
              Cancel
            </button>
          </>
        ) : (
          <>
            <VehicleSelection
              selectedVehicle={selectedVehicle}
              setSelectedVehicle={setSelectedVehicle}
            ></VehicleSelection>
            <PassagesList passages={passages} />
            <button
              className="bg-green-500 hover:bg-green-400 duration:50 transition p-5 rounded text-white mt-5"
              onClick={() => setAddingPassage(true)}
            >
              + New passage
            </button>
            {resultingPrice!==undefined && <PaymentResult fee={resultingPrice} />}
            <button
              className="bg-blue-500 hover:bg-blue-400 duration:50 transition p-5 rounded text-white mt-5"
              onClick={onGetTotalButtonClick}
            >
              Get total
            </button>
          </>
        )}
      </div>
    </div>
  );
}

export default App;
