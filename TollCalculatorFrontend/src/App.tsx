import { useEffect, useState } from "react";
import "./index.css";

function App() {
  const [vehicleType, setVehicleType] = useState();

  const [passages, setPassages] = useState<Date[]>([]);

  useEffect(() => {
    setPassages([]);
  }, [vehicleType]);

  const [resultingPrice, setResultingPrice] = useState();

  const onGetTotalButtonClick = () => {
    fetch("/api/toll", {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(passages),
    })
      .then((response) => response.json())
      .then((data) => setResultingPrice(data.price));
  };

  return (
    <div className=" min-h-screen flex flex-col justify-center items-center">
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
