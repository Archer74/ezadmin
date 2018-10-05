import * as R from "ramda";
import * as React from "react";
import { Col, Row } from "react-grid-system";
import { RouteComponentProps } from "react-router-dom";
import { ColumnInput } from "src/domain/generated/types";
import { AppPreview } from "../Engine/AppPreview";
import { DbTableDetail } from "./DbTableDetail/DbTableDetail";

type Props = RouteComponentProps<{ name: string; schema: string }>;
type State = {
  activeColumns: ColumnInput[];
};
class Designer extends React.Component<Props, State> {
  constructor(props: Props) {
    super(props);
    this.state = { activeColumns: [] };
  }
  public render() {
    const { name, schema } = this.props.match.params;

    return (
      <>
        <Row>
          <Col md={6} lg={3}>
            <DbTableDetail
              variables={{ tableName: name }}
              onCheckboxClick={(e, p) => this.toggleColumn(e, p)}
              isTableNameShown={this.state.activeColumns.length > 0}
            />
          </Col>
          {this.state.activeColumns.length > 0 && (
            <Col md={6} lg={9}>
              <AppPreview
                tableTitle={"test tabulky"}
                tableName={name}
                schemaName={schema}
                columns={this.state.activeColumns}
              />
            </Col>
          )}
        </Row>
      </>
    );
  }

  public toggleColumn = (
    column: ColumnInput,
    primaryColumn: ColumnInput
  ): void => {
    const isColumnInArray = this.areColumnsEqual(column);
    const columns = this.state.activeColumns.filter(e => !e.isHidden);

    const activeColumns = R.any(isColumnInArray, columns)
      ? R.filter(e => !isColumnInArray(e), columns)
      : R.append(column, columns);

    if (activeColumns.length > 0) {
      this.setState({ activeColumns: R.append(primaryColumn, activeColumns) });
    } else {
      this.setState({ activeColumns });
    }
  };

  public areColumnsEqual = (column1: ColumnInput) => (column2: ColumnInput) =>
    column1.columnName === column2.columnName &&
    column1.tableName === column2.tableName &&
    column1.schemaName === column2.schemaName;
}

export { Designer };
