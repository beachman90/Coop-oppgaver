import React, { useState, useEffect } from "react"

/* 
  Jeg har laget en enkel løsning for å sammenligne to land, og hvor mange flere innbyggere det ene landet har. 
  Bruker fetch for å hente info fra api'et, og har en auto complete funksjon på søkefeltene.
  Kunne funnet på noe mer komplisert, men ønsket å holde det enkelt.
*/ 

interface Country {
  name: { common: string }
  population: number
  flags: { png: string }
}

const CountryInfo: React.FC = () => {
  const [query, setQuery] = useState("")
  const [country, setCountry] = useState<Country | null>(null)
  const [query2, setQuery2] = useState("")
  const [country2, setCountry2] = useState<Country | null>(null)
  const [isLoading, setIsLoading] = useState(false)
  const [comparisonResult, setComparisonResult] = useState<string | null>(null)

  const fetchCountryData = async (
    query: string,
    setCountry: React.Dispatch<React.SetStateAction<Country | null>>
  ) => {
    if (query.length < 2) {
      setCountry(null)
      return
    }

    setIsLoading(true)
    try {
      const response = await fetch(
        `https://restcountries.com/v3.1/name/${query}`
      )
      if (!response.ok) {
        throw new Error("Country not found")
      }
      const data = await response.json()
      setCountry(data[0])
    } catch (error) {
      console.error("Failed to fetch country data", error)
      setCountry(null)
    } finally {
      setIsLoading(false)
    }
  }

  useEffect(() => {
    fetchCountryData(query, setCountry)
  }, [query])

  useEffect(() => {
    fetchCountryData(query2, setCountry2)
  }, [query2])

  const comparePopulations = () => {
    if (country && country2) {
      const populationDifference = Math.abs(
        country.population - country2.population
      )
      const morePopulousCountry =
        country.population > country2.population ? country : country2
      setComparisonResult(
        `${
          morePopulousCountry.name.common
        } has ${populationDifference.toLocaleString()} more people.`
      )
    } else {
      setComparisonResult(
        "Please ensure both countries are selected for comparison."
      )
    }
  }

  return (
    <div
      style={{
        fontFamily: "Arial, sans-serif",
        maxWidth: "600px",
        margin: "auto",
      }}
    >
      <div
        style={{
          padding: "20px",
          display: "flex",
          flexDirection: "column",
          gap: "10px",
        }}
      >
        <input
          type="text"
          value={query}
          onChange={(e) => setQuery(e.target.value)}
          placeholder="Search for a country..."
          style={{
            padding: "10px",
            fontSize: "16px",
            borderRadius: "5px",
            border: "1px solid #ccc",
          }}
        />
        <input
          type="text"
          value={query2}
          onChange={(e) => setQuery2(e.target.value)}
          placeholder="Search for another country..."
          style={{
            padding: "10px",
            fontSize: "16px",
            borderRadius: "5px",
            border: "1px solid #ccc",
          }}
        />
        <button
          onClick={comparePopulations}
          style={{
            padding: "10px 20px",
            fontSize: "16px",
            borderRadius: "5px",
            border: "none",
            backgroundColor: "#007BFF",
            color: "white",
            cursor: "pointer",
          }}
        >
          Compare
        </button>
      </div>
      <div>
        {isLoading && <p>Loading...</p>}
        <div
          style={{
            display: "flex",
            justifyContent: "space-around",
            flexWrap: "wrap",
            gap: "20px",
          }}
        >
          {country && (
            <div style={{ textAlign: "center" }}>
              <h2>{country.name.common}</h2>
              <p>Population: {country.population.toLocaleString()}</p>
              <img
                src={country.flags.png}
                alt={`Flag of ${country.name.common}`}
                style={{ width: "100px", borderRadius: "5px" }}
              />
            </div>
          )}
          {country2 && (
            <div style={{ textAlign: "center" }}>
              <h2>{country2.name.common}</h2>
              <p>Population: {country2.population.toLocaleString()}</p>
              <img
                src={country2.flags.png}
                alt={`Flag of ${country2.name.common}`}
                style={{ width: "100px", borderRadius: "5px" }}
              />
            </div>
          )}
        </div>
        {comparisonResult && (
          <p
            style={{
              textAlign: "center",
              marginTop: "20px",
              fontSize: "18px",
              fontWeight: "bold",
            }}
          >
            {comparisonResult}
          </p>
        )}
      </div>
    </div>
  )
}

export default CountryInfo
